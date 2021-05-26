{
    let exitFormButton = document.getElementById("exit-login-form");
    exitFormButton.addEventListener('click', exitLoginForm);

    let logotypeForm = document.getElementById("logotype-form");
    logotypeForm.addEventListener('click', exitLoginForm);
}

function exitLoginForm() {

    let loginForm = document.getElementById("login-form");

    HideAndBlock(loginForm, 600);
}