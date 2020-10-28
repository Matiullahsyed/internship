function ajaxCalls(controller,parameter,object,method,success,fail){
    var url= "https://localhost:44386/api/";
    url += controller;

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