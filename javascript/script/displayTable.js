function displayTable(){
    var studentArray = JSON.parse(localStorage.getItem("information"));

    
    //var table = document.getElementById("myTable");
    if (studentArray != null) {
    for (i = 0; i < studentArray.length; i++) {
        var row = `<tr>
    
           <td>${studentArray[i].name}</td>
           <td>${studentArray[i].email}</td>
           <td>${studentArray[i].contact}</td>
           <td>${studentArray[i].password}</td>
           <td>${studentArray[i].conformPassword}</td>
           
           <td><button id="edit-${i}" onclick="editStudent(${i})" data-id="${i}"><a href="./Student.html">Edit</a></button></td>
           <td><button id="delete-${i}" onclick="deleteStudent(${i})" data-id="${i}">Delete</button></td>
           
           </tr>`;
        document.getElementById('mytbody').innerHTML += row;
    }
    }
        
    }

function editStudent(index){
 localStorage.setItem("id",index);
}

function deleteStudent(index){
    var studentArray = JSON.parse(localStorage.getItem("information"));
    studentArray.splice(index,1);
    localStorage.setItem("information",JSON.stringify(studentArray));
    window.location.reload();
}


displayTable();