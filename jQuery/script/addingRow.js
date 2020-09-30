function addingRow(){
    var studentArray = JSON.parse(localStorage.getItem("info"));
    let index = studentArray.length;

    var row=`<tr >
    <td><input id="iname-${index}" type="text" name="name"><td>
    <td><input id="iemail-${index}" type="email" name="email"><td>
    <td><input id="icontact-${index}" type="text" name="phone"><td>
    <td><input id="ipassword-${index}" type="password" name="password"><td>
    <td><input id="iconfirmpassword-${index}" type="password" name="confirmpassword"><td>
    <td><button id="aa" onclick=savingRow(${index}) >Save</button></td>
    <td><button id="bb">Cancel</button></td>

     </tr>`;
        $('#forRow').append(row);
        $('#aa').click(function(){
            savingRow(index);
            
        });
        $('#bb').click(function(){
            cancelRow();
            
        });
    }
    
    function displayTable(){
        var studentArray = JSON.parse(localStorage.getItem("info"));
    
        if (studentArray != null) {
        for (i = 0; i < studentArray.length; i++) {
            var row = `<tr>
        
               <td><span id="name-${i}">${studentArray[i].name}</span><input id="iname-${i}" type="text" ></td>
               <td><span id="email-${i}">${studentArray[i].email}</span><input id="iemail-${i}" type="email" ></td>
               <td><span id="contact-${i}">${studentArray[i].contact}</span><input id="icontact-${i}" type="contact" ></td>
               <td><span id="password-${i}">${studentArray[i].password}</span><input id="ipassword-${i}" type="password" ></td>
               <td><span id="confirmpassword-${i}">${studentArray[i].conformPassword}</span><input id="iconfirmpassword-${i}" type="password" ></td>
               
               <td><button id="edit-${i}" onclick="editRow(${i},this)" data-id="${i}">Edit</button></td>
               <td><button id="delete-${i}" onclick="deleteRow(${i},this)" data-id="${i}">Delete</button></td>
               
               </tr>`;

            $('#forRow').append(row);
            $(document).find('span').show();
            $(document).find('input').hide();            
        }
        }
            
        }
        displayTable();

        function editRow(index,obj){

            debugger
            $(obj).parent().parent().find('span').hide();
            $(obj).parent().parent().find('input').show();
           let arrayForRow=JSON.parse(localStorage.getItem("info"));
            let jsonObject=arrayForRow[index];
            $(`#iname-${index}`).val(jsonObject.name);
            $(`#iemail-${index}`).val(jsonObject.email);
            $(`#icontact-${index}`).val(jsonObject.contact);
            $(`#ipassword-${index}`).val(jsonObject.password);
            $(`#iconfirmpassword-${index}`).val(jsonObject.conformPassword);

            $(obj).hide();
            $('#delete-' + index).hide();
            $(`#edit-${i}`).parent().remove();
            $(`#iconfirmpassword-${index}`).parent().after(`<td><button onclick="cancelRow(${index})" id="cancel-${i}">cancel</button></td>`);
            $(`#iconfirmpassword-${index}`).parent().after(`<td><button onclick="savingRow(${index})" id="save-${i}">save</button></td>`);
            
            // $("#edit-${i}" ).remove();
            return false;
           }

           
    
function storingInfo(student,index){
    let array1 = JSON.parse(localStorage.getItem("info"));
    if(array1==null) array1=[];
    array1.splice(index,1,student);
    localStorage.setItem("info",JSON.stringify(array1));
    location.reload();
    
}

function savingRow(index){
    let student = {
        name : $(`#iname-${index}`).val(),
        email :$(`#iemail-${index}`).val(),
        contact: $(`#icontact-${index}`).val(),
        password:$(`#ipassword-${index}`).val(),
        conformPassword:$(`#iconfirmpassword-${index}`).val(),
        
    }
    storingInfo(student,index);
    window.location.reload();
    
}
function deleteRow(index){
    var studentArray = JSON.parse(localStorage.getItem("info"));
    studentArray.splice(index,1);
    localStorage.setItem("info",JSON.stringify(studentArray));
    window.location.reload();
}
function cancelRow(){
    window.location.reload();
}

