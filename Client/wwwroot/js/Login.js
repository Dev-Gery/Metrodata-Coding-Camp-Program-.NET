function Login() {
    event.preventDefault();
    var loginVM = {
        Email: $("#floatingInput").val(),
        Password: $("#floatingPassword").val(),
    };
    $.ajax({
        url: "accounts/login",
        type: "POST",
        dataType: 'json',
        data: loginVM
    }).done((results) => {
        console.log(results);
        if (results.status == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Login success',
                showConfirmButton: false,
                timer: 1500
            }).then(function () {
                location.reload();
            }
            );
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Login Failed',
                text: results.message,
                footer: '<a href="">Lupa Password?</a>'
            }).then(function () {
            }
            );
        }
    }).fail((error) => {
        console.log(error);
        Swal.fire({
            icon: 'error',
            title: 'Login failed',
            text: "Something's wrong",
            footer: '<a href="">call the manager</a>'
        }).then(function () {
        }
        );
    })
}
