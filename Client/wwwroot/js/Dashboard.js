$(document).ready(function () {
    $('#TabelMasterData').DataTable({
        dom: "<'row'<'col-md-3'l><'col-md-5'B><'col-md-4'f>>" +
            "<'row'<'col-md-12'tr>>" +
            "<'row'<'col-md-5'i><'col-md-7'p>>",
        columnDefs: [{
            targets: -1,
            className: 'ignore'
        }],
        buttons: [
            {
                extend: 'copy',
                exportOptions: {
                    columns: ':not(.ignore)'
                }
            },
            {
                extend: 'csv',
                exportOptions: {
                    columns: ':not(.ignore)'
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: ':not(.ignore)'
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    columns: ':not(.ignore)'
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: ':not(.ignore)'
                }
            }
        ],
        "filter": true,
        "orderMulti": false,
        "ajax": {
            "url": "accounts/masterdata",
            "datatype": "json",
            "dataSrc": "result"  
        },
        "columns": [
            {
                "data": "nik"
            },
            {
                "data": "fullName"
            },
            {
                "data": "gender"
            },
            {
                "data": "birthDate",
                "render": function (data, type, row) {
                    return moment(row["birthDate"]).format('LL');
                }
            },
            {
                "data": "phone",
                "render": function (data, type, row) {
                    return "+62" + row["phone"].substring(1);
                },
                "autoWidth": true
            },
            {
                "data": "email"
            },
            {
                "data": "role_Names"
            },
            {
                "data": "salary",
                "render": function (data, type, row) {
                    return "RP" + row["salary"];
                },
                "autoWidth": true
            },
            {
                "data": null,
                "orderable": false,
                render: function (data, type, row, meta) {
                    return `<div class="row">
                                <div class="col-md-5">
                                <button class="btn btn-warning fa-solid fa-pen-to-square" onClick="GetUpdateModal('${row.nik}')" data-toggle="modal" data-hover="tooltip"  data-placement="right" title="Edit" data-target="#updateForm">
                                </div>
                                <div class="col-md-5">
                                </button> <button class="btn btn-danger fa-solid fa-trash-can" onClick="Delete('${row.nik}')" data-hover="tooltip" data-placement="right" title="Delete"></button>
                                </div>
                            </div>`;
                },
                "autowidth": true
            },
        ],
    });
});

let universityData = [];
$.ajax({
    url: "universities/getall",
    success: function (results) {
        var result = results.result;
        console.log(result);
        let text = `<option selected value="">Choose...</option>`;
        $.each(result, function (key, val) {
            universityData.push({ x: val.name, y: 0 });
            text += `<option type="number" value=${val.id}>${val.name}</option>`
        });
        $("#uni").html(text);
    }
})

$.ajax({
    url: "accounts/masterdata",
    success: function (results) {
        var result = results.result;
        let genderDataArray = [0, 0];
        $.each(result, function (key, val) {

            if (val.gender == "Male") {
                genderDataArray[0] += 1;
            }
            else {
                genderDataArray[1] += 1;
            }

            for (var i = 0; i < universityData.length; i++) {
                if (universityData[i].x == val.university_Name) {
                    universityData[i].y += 1;
                    break;
                }
            }
        });

        var options = {
            chart: {
                type: "pie",
                selection: {
                    enabled: true
                },
                toolbar: {
                    show: true,
                    tools: {
                        download: true,
                    },
                    offsetX: -10,
                    offsetY: 0
                }
            },
            series: genderDataArray,
            labels: ["Male", "Female"]
        }
        var chart = new ApexCharts(document.querySelector("#genderchart"), options)
        chart.render();

        var options = {
            chart: {
                height: 420,
                type: "bar"
            },
            series: [{
                name: "counts",
                data: universityData
            }],
            xaxis: {
                type: 'category'
            }
        }
        var chart = new ApexCharts(document.querySelector("#unichart"), options)
        chart.render();
    }
})

function Insert() {
    event.preventDefault();
    var emp = {
        FirstName : $("#firstname").val(),
        LastName : $("#lastname").val(),
        Phone : $("#phone").val(),
        Email : $("#email").val(),
        Gender : $("#gender").val(),
        Password : $("#password").val(),
        Degree : $("#degree").val(),
        GPA : $("#gpa").val(),
        University_Id: $("#uni").val(),
        Salary : $("#salary").val(),
        Birthdate: $("#birthdate").val()
    };
    $.ajax({
        url: "accounts/register",
        type: "POST",
        dataType: 'json',
        data: emp
    }).done((result) => {
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'New employee data has been saved',
            showConfirmButton: false,
            timer: 1500
        }).then(function () {
            location.reload();
        }
        );
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Registration failed',
            text: "Invalid data",
            footer: '<a href="">Check the backend programming</a>'
        }).then(function () {
        }
        );
    })
}

function GetUpdateModal(nik) {
    $.ajax({
        url: `employees/get/${nik}`,
        success: function (result) {
            $('#unik').attr('value', `${nik}`);
            $('#ufirstname').attr('value', `${result.firstName}`);
            $('#ulastname').attr('value', `${result.lastName}`);
            $('#uemail').attr('value', `${result.email}`);
            $('#uphone').attr('value', `${result.phone}`);
            $('#ubirthdate').attr('value', `${result.birthDate}`.toString().substring(0, 10));
            $('#usalary').attr('value', `${result.salary}`);
            //var currentgender; var altgender; var altgenderval;
            if (result.gender == 0) {
                $('#ugender').val("0")
            }
            else {
                $('#ugender').val("1")
            };
        }
    });
}

function Update() {
    event.preventDefault();
    var emp = {
        nik: $("#unik").val(),
        firstName: $("#ufirstname").val(),
        lastName: $("#ulastname").val(),
        phone: $("#uphone").val(),
        email: $("#uemail").val(),
        gender: $("#ugender").val(),
        salary: $("#usalary").val(),
        birthDate: $("#ubirthdate").val()
    };
    $.ajax({
        url: `employees`,
        type: "PUT",
        dataType: 'json',
        data: emp
    }).done((result) => {
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: `The new data of ${emp.nik} has been saved`,
            showConfirmButton: false,
            timer: 1500
        }).then(function () {
            location.reload();
        }
        );
    }).fail((error) => {
        Swal.fire({
            position: 'center',
            icon: 'failed',
            title: `Edit Failed`,
            showConfirmButton: false,
            timer: 1500
        })
    });
}

function Delete(nik) {
    Swal.fire({
        title: `Do you want to delete ${nik}?`,
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `employees/${nik}`,
                type: "DELETE"
            }).done((result) => {
                Swal.fire({
                    title: "Delete Successful", text: `The employee data with NIK ${nik} has been deleted`,
                    type: "success"
                }).then(function () {
                    location.reload();
                }
                );
            }).fail((error) => {
                Swal.fire({
                    title: "Delete Failed", text: "Something went wrong!",
                    type: "failed"
                }).then(function () {
                    location.reload();
                }
                );
            });
        }
    })
}
