function Login() {
    event.preventDefault();
    var loginVM = {
        Email: $("#floatingInput").val(),
        Password: $("#floatingPassword").val(),
    };
    $.ajax({
        url: "logins/authenticate",
        type: "POST",
        dataType: 'json',
        data: loginVM
    }).done((results) => {
        console.log(results);
        switch (results.status) {
            case 200:
                swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'login success',
                    showConfirmButton: false,
                    timer: 1500
                }).then(function () {
                    window.location.href = "dashboard";
                });
                break;
            default:
                swal.fire({
                    icon: 'error',
                    title: 'login failed',
                    text: results.message,
                    footer: '<a href="">lupa password?</a>'
                }).then( function(){ } );
        };
    }).fail((error) => {
        console.log(error);
        Swal.fire({
            icon: 'error',
            title: 'Login failed',
            text: "Something's wrong",
            footer: '<a href="">call the manager</a>'
        }).then( function(){ } );
    })
}

