var courseToEdit;

function refillStudentCourseForm(){

    var option="";

    
        ajaxCalls(
           "course",
            null,
            null,
            "GET",
            (data) =>{
                courseToEdit = JSON.parse(JSON.stringify(data));
                console.log(courseToEdit);
                data.forEach(function(value) {
                    option +=`<option class="opt" value="${value.CourseId}">${value.Name}</option>`
                });
                $('#ccourseRecord').append(option);
            },
            ()=>{
                alert("fail to GET Courses");
            }
        ); 

    var id=localStorage.getItem("id");
    ajaxCalls( "student","?Id="+id,null,"GET",
        (data) =>{
            console.log("edit data");
            console.log(data);
            $("#cname").val(data.student.Name);
            $("#cemail").val(data.student.Email);
            $("#ccontact").val(data.student.Contact);
           $('.opt').each(function(){
               var opt=$(this);
            data.Courses.forEach(function(value){
                debugger;
                if (opt.val() == value.CourseId) {
                    opt.prop("selected", true);
                }
            });
           });
            $("#cpassword").val(data.student.Password);
            $("#cconfirmpassword").val(data.student.ConfirmPassword);
        },
        ()=>{
            alert("Not Working");
        }
    );
   
  
   
    
};
function displayCourse(){

    
return course;
}

