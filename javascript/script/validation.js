function namedFieldCheck(name) {
    return /^[a-zA-Z ]{3,30}$/.test(name);
}

function emailFieldCheck(email) {
    return /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/.test(email);
}

function phoneFieldCheck(phone) {
    return /^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/.test(phone);
}

function passwordFieldCheck(password) {
    return /^(?=.*[\d])(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*])[\w!@#$%^&*]{8,}$/.test(password);
}