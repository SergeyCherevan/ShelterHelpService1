{
    let accountButton = document.getElementById("account-button");
    accountButton.addEventListener('click', accountButtonClick);

    let alreadyRegistredButton = document.getElementById("already-registred");
    alreadyRegistredButton?.addEventListener('click', accountButtonClick);
}

function accountButtonClick() {

    let loginForm = document.getElementById("login-form");

    UnblockAndShow(loginForm, 600);
}