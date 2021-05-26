{
    let accountButton = document.getElementById("account-button");
    accountButton.addEventListener('click', showLoginForm);

    let alreadyRegistredButton = document.getElementById("already-registred");
    alreadyRegistredButton?.addEventListener('click', showLoginForm);
}

function showLoginForm() {

    let loginForm = document.getElementById("login-form");

    UnblockAndShow(loginForm, 600);
}