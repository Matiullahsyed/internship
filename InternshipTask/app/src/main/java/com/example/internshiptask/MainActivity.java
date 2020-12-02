package com.example.internshiptask;
import androidx.appcompat.app.AppCompatActivity;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.content.Intent;
import android.graphics.Color;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import java.util.ArrayList;
import java.util.List;
import okhttp3.OkHttpClient;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class MainActivity extends AppCompatActivity {
    private TextView textViewResult;
    private List<CourseDto> AllCourseDto;
    public String[] Courses;
    public ArrayList<Integer> CoursesWithIds = new ArrayList<>();
    //Delete Start
    public void delete(int id){
        Retrofit retrofit = okHttpClientObject.okHttpClientObjectApiCall();
        JsonApiPlaceHolder jsonApiPlaceHolder= retrofit.create(JsonApiPlaceHolder.class);
        Call<String> call = jsonApiPlaceHolder.deleteStudent(id);
        call.enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                Log.e("Response", response.message());
                Intent intent = new Intent(MainActivity.this,MainActivity.class);
                startActivity(intent);
            }
            @Override
            public void onFailure(Call<String> call, Throwable t) {
                Log.e("Error", t.getMessage());
            }
        });
    }
    //Edit Button
    public void edit(int id){
        Intent intent = new Intent(MainActivity.this,AddStudent.class);
        intent.putExtra("id",id);
        startActivity(intent);
    }
    //Buttons
    public void addButton(String dataToDisplay, LinearLayout linearLayout, LinearLayout.LayoutParams lparams, int studentId){
        Button button = new Button(MainActivity.this);
        button.setText(dataToDisplay);
        button.setTextColor(Color.BLACK);
        if(dataToDisplay == "Delete"){
            button.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    delete(studentId);
                }
            });
        }else{
            button.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    edit(studentId);
                }
            });
        }
        linearLayout.addView(button);
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button addButton = findViewById(R.id.addBtn);
        addButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i =new Intent(MainActivity.this, AddStudent.class);
                startActivity(i);
            }
        });
        //GetStudent Start//
        Retrofit retrofit = okHttpClientObject.okHttpClientObjectApiCall();
        JsonApiPlaceHolder jsonApiPlaceHolder= retrofit.create(JsonApiPlaceHolder.class);
        Call<List<StudentDto>> call =jsonApiPlaceHolder.getStudents();
        call.enqueue(new Callback<List<StudentDto>>() {
            @Override
            public void onResponse(Call<List<StudentDto>> call, Response<List<StudentDto>> response) {
                if(!response.isSuccessful()){
                    Log.e("error status", response.message());
                    return;
                }
                List<StudentDto> students= response.body();
                for(StudentDto student :students){
                    LinearLayout linearLayout=findViewById(R.id.linearlayout);
                    String content="";
                    content+="ID: "+student.student.getId()+"\n";
                    content+="Name: "+student.student.getName()+"\n";
                    content+="Email: "+student.student.getEmail()+"\n";
                    content+="Contact: "+student.student.getContact()+"\n";
                    content+="Password: "+student.student.getPassword()+"\n";
                    content+="ConfirmPassword: "+student.student.getConfirmPassword()+"\n\n";
                    // Dynamically Adding TextView//
                    TextView studentTextView = new TextView(MainActivity.this);
                    LinearLayout.LayoutParams lparams = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.WRAP_CONTENT);
                    studentTextView.setLayoutParams(lparams);
                    studentTextView.setText(content);
                    linearLayout.addView(studentTextView);
                    addButton("Edit",linearLayout,lparams, student.student.getId());
                    addButton("Delete",linearLayout,lparams,student.student.getId());
                }
            }
            //End Get//
            @Override
            public void onFailure(Call<List<StudentDto>> call, Throwable t) {
                Log.e("Error", "failed" );
            }
        });
        //Notifications Channel Regestrations
        if( Build.VERSION.SDK_INT >= Build.VERSION_CODES.O){
            NotificationChannel channel=
                    new NotificationChannel(  "MyNotifications" ,  "MyNotifications", NotificationManager.IMPORTANCE_DEFAULT );
            NotificationManager manager= getSystemService(NotificationManager.class);
            manager.createNotificationChannel((channel));
        }
    }
}