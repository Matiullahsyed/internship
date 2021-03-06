function storingInLocalStorage(student){
    let array = JSON.parse(localStorage.getItem("information"));
    if(array==null) array=[];
    array.push(student);
    localStorage.setItem("information",JSON.stringify(array));
    
}

function validate(studentData){
    var validation = true;

if(!namedFieldCheck(studentData.name)){
    alert("Name is not valid");
    validation = false;
}else if(!emailFieldCheck(studentData.email)){
    alert("email is not valid");
    validation = false;
}else if(!phoneFieldCheck(studentData.contact)){
    alert("Phone number is not valid");
    validation = false;
}
// else if(!passwordFieldCheck(studentData.password)){
//     alert("password is not valid");
//     validation = false;
// }else if(!passwordFieldCheck(studentData.conformPassword)){
//     alert("password is not valid");
//     validation = false;
// }

if(validation)
    return true;
}

function updateStudent(student){
    var studentArray = JSON.parse(localStorage.getItem("information"));
    var id = JSON.parse(localStorage.getItem("id"));

    studentArray.splice(id,1,student);
    localStorage.setItem("information",JSON.stringify(studentArray));
    localStorage.removeItem("id");
}

function setForm(){
    var index = JSON.parse(localStorage.getItem("id"));
    if(index != null){
        var studentArray = JSON.parse(localStorage.getItem("information"));
        var student = {...studentArray[index]};

           $("#sname").val(student.name)  ;
           $("#semail").val(student.email)  ;
           $("#scontactNumber").val(student.contact);
           $("#spassword").val(student.password) ;
           $("#sconfirmpassword").val(student.conformPassword);
    }
}

function studentPannel(){
    
    let student = {
        name : $("#sname").val(),
        email :$("#semail").val(),
        contact: $("#scontactNumber").val(),
        password:$("#spassword").val(),
        conformPassword:$("#sconfirmpassword").val(),
    }
    
    if(validate(student)){
        if(JSON.parse(localStorage.getItem("id")) != null ){
        updateStudent(student);
        window.location.href = "./studentsList.html";
        }else{
            storingInLocalStorage(student);
        }
    }
    
}


setForm();