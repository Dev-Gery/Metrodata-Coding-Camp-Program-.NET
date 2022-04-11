$(document).ready(function () {
    $('.TabelMasterData').DataTable({
        dom: "<'row justify-content-between align-items-center'<'col-md-3'l><'d-flex align-items-center justify-content-center'<'mr-3'B><'mt-1'f>>>" +
            "<'row'<'col-md-12'tr>>" +
            "<'row'<'col-md-5'i><'col-md-7'p>>",
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        "filter": true,
        "orderMulti": false,
        "ajax": {
            "url": "https://localhost:44327/api/accounts/masterdata",
            "datatype": "json",
            "dataSrc": ""
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
                    return row["birthDate"].toString().substring(0,10);
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
                render: function (data,type,row, meta) {
                    return `<button class="btn btn-primary" onClick="GetUpdateModal('${row.nik}')" data-toggle="modal" data-target="#updateForm">Edit</button><br>
                            <button class="btn btn-primary" onClick="Delete('${row.nik}')">Delete</button>`;
                },
            },
        ],
    });
});

function GetUniData() {
    $.ajax({
        url: "https://localhost:44327/api/universities/",
        success: function (results) {
            console.log(results.result);
            var text = `<option selected value="">Choose...</option>`;
            $.each(results.result, function (key, val) {
                text += `<option type="number" value="${val.id}">${val.name}</option>`
            });
            console.log(text);
            $("#uni").html(text);
        }
    })
}

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
        University_Id : $("#uni").val(),
        Salary : $("#salary").val(),
        Birthdate: $("#birthdate").val()
    };
    $.ajax({
        url: "https://localhost:44327/api/accounts/register",
        type: "POST",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
        },
        dataType: 'json',
        data: JSON.stringify(emp),
    }).done((result) => {
        alert("Registration success");
        location.reload();
    }).fail((error) => {
        alert("Registration error");
})
}

function GetUpdateModal(nik) {
    $.ajax({
        url: `https://localhost:44327/api/employees/${nik}`,
        success: function (results) {
            var result = results.result;
            $('#unik').attr('value', `${nik}`);
            $('#ufirstname').attr('value', `${result.firstName}`);
            $('#ulastname').attr('value', `${result.lastName}`);
            $('#uemail').attr('value', `${result.email}`);
            $('#uphone').attr('value', `${result.phone}`);
            $('#ubirthdate').attr('value', `${result.birthDate}`.toString().substring(0, 10));
            $('#usalary').attr('value', `${result.salary}`);
            var currentgender; var altgender; var altgenderval;
            if (result.gender == 0) {
                currentgender = "Male";
                altgender = "Female";
                altgenderval = 1;
            }
            else {
                currentgender = "Female";
                altgender = "Male";
                altgenderval = 0;
            };
            $('#ugender').html(`<option selected>${currentgender}</option>
                                <option type="number" value="${altgenderval}">${altgender}</option>`);
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
        url: "https://localhost:44327/api/employees",
        type: "PUT",
        //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify(data );)
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
        },
        dataType: 'json',
        data: JSON.stringify(emp),
    }).done((result) => {
        alert("Edit success");
        location.reload();
        //buat alert pemberitahuan jika success
    }).fail((error) => {
        alert("Edit error");
        location.reload();
    });
}

function Delete(nik) {
    $.ajax({
        url: `https://localhost:44327/api/employees/${nik}`,
        type: "DELETE"
    }).done((result) => {
        alert("Employee with NIK " + nik + " just got deleted");
        location.reload();
    }).fail((error) => {
        alert("Failed to delete " + nik + ". Something's wrong");
        location.reload();
    });
}