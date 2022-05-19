/* table data read and population */
//$.fn.dataTable.ext.buttons.reload = {
//    text: 'Reload',
//    action: function (e, dt, node, config) {
//        dt.ajax.reload();
//    }
//};
$.fn.dataTable.ext.buttons.registration = {
    text: 'Register',
    action: function (e, dt, node, config) {
        $('#registrationForm').modal('show')
    }
};
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
            'registration',
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
            url: "https://localhost:44357/accounts/masterdata",
            datatype: "json",
            dataSrc: "result"  
        },
        "columns": [
            //{
            //    "name": "rownum",
            //    orderable: false,
            //    autoWidth: true,
            //    render: function (data, type, row, meta) {
            //        return meta.row + 1
            //    }
            //},
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
                "name": "birthdate",
                "data": null,
                "render": function (data, type, row) {
                    return moment(row["birthDate"]).format('LL');
                }
            },
            {
                "name": "phone",
                "data": null,
                "render": function (data, type, row) {
                    let phone = data["phone"];
                    if (phone != null && phone != '') {
                        if (phone[0] == '0') {
                            return "+62" + phone.substring(1);
                        }
                    }
                    return phone;
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
                "name": "salary",
                "data": null,
                "render": function (data, type, row) {
                    let sal = data['salary'].toString();
                    let salLength = sal.length;
                    if (salLength > 3) {
                        var newSal = '';
                        if (salLength % 3 != 0) {
                            newSal = sal.substring(0, salLength % 3);
                        }
                        else {
                            newSal = sal.substring(0, 3)
                        }
                        for (var i = newSal.length; i < salLength; i += 3) {
                            newSal += '.' + sal.substring(i, i + 3);
                        }
                        sal = newSal;
                    }
                    return "Rp" + sal + ",00";
                },
                "autoWidth": true
            },
            {
                "name": "actions",
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

 /* charts */
let universityData = [];
$.ajax({
    url: "https://localhost:44357/universities",
    success: function (results) {
        var result = results.result;
        let text = `<option selected value="">Choose...</option>`;
        $.each(result, function (key, val) {
            universityData.push({ x: val.name, y: 0 });
            text += `<option type="number" value=${val.id}>${val.name}</option>`
        });
        $("#uni").html(text);
    }
})

$.ajax({
    url: "https://localhost:44357/accounts/masterdata",
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
        console.log("genders", genderDataArray);
        console.log("universities", universityData);
        var optionGender = {
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
        var chart = new ApexCharts(document.querySelector("#gendersChart"), optionGender)
        chart.render();

        var optionUni = {
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
        var chart = new ApexCharts(document.querySelector("#universitiesChart"), optionUni)
        chart.render();
    }
})

/* insert,update,delete */
function Insert() {
    event.preventDefault();
    var register = {
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
    console.log(register);
    $.ajax({
        url: "https://localhost:44357/accounts/register",
        type: "POST",
        dataType: 'json',
        data: register
    }).done((results) => {
        switch (results.status) {
            case 200:
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'New employee data has been saved',
                    showConfirmButton: false,
                    timer: 1500
                }).then(function(){ location.reload() });
                break;
            default:
                //might add custom validation specifically to the form fields
                //var message = results.message;
                //if (message.toLowerCase().contains("phone")) {
                //    $('#phonefdbck').html(message);
                //    <script>?
                //}
                //...etc
                Swal.fire({
                    icon: 'error',
                    title: 'Registration failed',
                    text: results.message,
                    footer: '<a href="">Check the backend programming</a>'
                }).then(function () { });        
        }
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Registration failed',
            text: "Invalid data",
            footer: '<a href="">Check the backend programming</a>'
        }).then(function () { });
    })
}

function GetUpdateModal(nik) {
    $.ajax({
        url: `https://localhost:44357/employees/${nik}`,
        success: function (results) {
            var result = results.result;
            $('#unik').val(`${nik}`);
            $('#ufirstname').val(`${result.firstName}`);
            $('#ulastname').val(`${result.lastName}`);
            $('#uemail').val(`${result.email}`);
            $('#uphone').val(`${result.phone}`);
            $('#ubirthdate').val(`${result.birthDate}`.toString().substring(0, 10));
            $('#usalary').val(`${result.salary}`); 
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
        url: `https://localhost:44357/employees`,
        type: "PUT",
        dataType: 'json',
        data: emp
    }).done((results) => {
        console.log(results);
        switch (results.status) {
            case 200:
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: `The new data of ${emp.nik} has been saved`,
                    showConfirmButton: false,
                    timer: 2500
                }).then(function () { location.reload() });
                break;
            default:
                //might add custom validation specifically to the form fields
                //var message = results.message;
                //if (message.toLowerCase().contains("phone")) {
                //    $('#phonefdbck').html(message);
                //    <script>?
                //}
                //...etc
                Swal.fire({
                    icon: 'error',
                    title: 'Registration failed',
                    text: results.message,
                    footer: '<a href="">Check the backend programming</a>'
                }).then(function () { });
        }
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
                url: `https://localhost:44357/employees/${nik}`,
                type: "DELETE"
            }).done((results) => {
                if (results.status == 200) {
                    Swal.fire({
                        title: "Delete Successful", text: `The employee data with NIK ${nik} has been deleted`,
                        type: "success"
                    }).then(function () {
                        location.reload();
                    }
                    );
                }
                else {
                    Swal.fire({
                        title: "Delete Failed", text: results.message,
                        type: "failed"
                    }).then(function() { location.reload() });
                }
            }).fail((error) => {
                Swal.fire({
                    title: "Delete Failed", text: "Something went wrong!",
                    type: "failed"
                }).then(function() { location.reload() });
            });
        }
    })
}
