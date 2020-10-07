let dataFromApi;
let student = {};
let url= "https://localhost:44386/api/student";

function ajaxCalls(parameter,object,method,success,fail){
if (parameter){
    url +=parameter;
}
$.ajax({
    url:url,
    data:object,
    method:method,
    success:function(data){
        typeof success=="function"
        ? success(data)
        : alert("Functon not success");
    },
    
}).fail(function(){
    fail();
});
};

function refillForm(index){

    $("#iname-"+index).val(dataFromApi[index].Name);
    $("#iemail-"+index).val(dataFromApi[index].Email);
    $("#icontact-"+index).val(dataFromApi[index].Contact);
    $("#ipassword-"+index).val(dataFromApi[index].Password);
    $("#iconfirmpassword-"+index).val(dataFromApi[index].ConfirmPassword);

};
function jsonData(index){
   student.Name= $(`#iname-${index}`).val();
   student.Email=$(`#iemail-${index}`).val();
   student.Contact=$(`#icontact-${index}`).val();
   student.Password=$(`#ipassword-${index}`).val();
   student.ConfirmPassword=$(`#iconfirmpassword-${index}`).val();
   return student;

};


function gettingDataFromApi(){
    ajaxCalls(
        "",
        null,
        "GET",
        (data) =>{
            dataFromApi = JSON.parse(JSON.stringify(data));
            console.log(dataFromApi);
            displayTable(data);
        },
        ()=>{
            alert("fail to GET students");
        }
    );
}

gettingDataFromApi();

function addingRow(){
    
     var studentArray = dataFromApi;
    let index = studentArray.length;
    
    var row=`<tr >
    <td><input id="iname-${index}" type="text" name="name"><td>
    <td><input id="iemail-${index}" type="email" name="email"><td>
    <td><input id="icontact-${index}" type="text" name="phone"><td>
    <td><input id="ipassword-${index}" type="password" name="password"><td>
    <td><input id="iconfirmpassword-${index}" type="password" name="confirmpassword"><td>
    <td><button id="save-${index}"  onclick=savingRow(${index},this) >Save</button></td>
    <td><button id="btn-cancel">Cancel</button></td>

     </tr>`;
        $('#forRow').append(row);
     
        $('#btn-cancel').click(function(){
            cancelRow(index);
            
        });
    }
    
function displayTable(){

        console.log(dataFromApi);
    // get data from database
    
        if (dataFromApi != null) {
        for (i = 0; i < dataFromApi.length; i++) {

            console.log(dataFromApi[i]);
            var row = `<tr>
        
               <td><span id="name-${i}">${dataFromApi[i].Name}</span><input id="iname-${i}" type="text" ></td>
               <td><span id="email-${i}">${dataFromApi[i].Email}</span><input id="iemail-${i}" type="email" ></td>
               <td><span id="contact-${i}">${dataFromApi[i].Contact}</span><input id="icontact-${i}" type="contact" ></td>
               <td><span id="password-${i}">${dataFromApi[i].Password}</span><input id="ipassword-${i}" type="password" ></td>
               <td><span id="confirmpassword-${i}">${dataFromApi[i].ConfirmPassword}</span><input id="iconfirmpassword-${i}" type="password" ></td>
               
               <td><button id="edit-${i}" onclick="editRow(${i},this)" data-id="${i}">Edit</button></td>
               <td><button id="delete-${i}" onclick="deleteRow(${dataFromApi[i].Id},this)" data-id="${i}">Delete</button></td>
               
               </tr>`;

            $('#forRow').append(row);
            
            $(document).find('span').show();
            $(document).find('input').hide();  
                    
        }
        }
            
        }
       

function editRow(index,obj){
            $(obj).parent().parent().find('span').hide();
            $(obj).parent().parent().find('input').show();
            $(`#delete-${index}`).after(`<button id="save-${index}" onclick="savingRow(${index})">save </button>`);
            
            $(`#edit-${index}`).hide();
            $(`#delete-${index}`).hide();
            refillForm(index);
            
            
           }
function storingInfo(index){

   
    if(index !==dataFromApi.length){
        var studentId = dataFromApi[index].Id;
        var student = jsonData(index);
        student.Id = studentId;
        var data = student;

        ajaxCalls(
            "",
            data,
            "PUT",
            (data) =>{
            },
            ()=>{
                alert("Not Working");
            }
            
        );

    }
    else{
    var data=jsonData(index);

    ajaxCalls(
        "",
        data,
        "POST",
        (data) =>{
        },
        ()=>{
            alert("Not Working");
        }
        
    );

}

}

function savingRow(index){
   
    storingInfo(index);

        displayTable();
        
}
function deleteRow(id){
    debugger;
    ajaxCalls(
        "?Id="+id,
        null,
        "DELETE",
        (data) =>{

        },
        ()=>{
            alert("Not Working");
        }
        
    );

    
}
function cancelRow(){
    window.location.reload();
}

