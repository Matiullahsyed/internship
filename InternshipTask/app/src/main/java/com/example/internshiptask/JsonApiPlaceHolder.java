package com.example.internshiptask;
import java.util.List;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
public interface JsonApiPlaceHolder {
    @GET("student")
    Call<List<StudentDto>> getStudents();
    @GET("course")
    Call<List<CourseDto>> getCourses();
    @GET("student/{id}")
    Call<StudentDto> getOneStudent(@Path("id") int id);
    @POST("student")
    Call<List<StudentDto>> postStudent(@Body StudentDto studentDto);
    @DELETE("student/{id}")
    Call<String> deleteStudent(@Path("id") int id);
    @PUT("student")
    Call<String>  eidtStudent(@Body Student student);
}
