package com.example.internshiptask;
import androidx.appcompat.app.AppCompatActivity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
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
public class AddStudent extends AppCompatActivity {
    Button mOrder;
    TextView mItemSelected;
    private List<CourseDto> AllCourseDto;
    public String[] Courses;
    boolean checkCourses [];
    int studentid;
    EditText name,  email, contact, password, confirmpassword;
    ArrayList<Integer> userCheckCourses =new ArrayList<>();
    public ArrayList<Integer> CoursesWithIds = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_student);
        studentid= getIntent().getIntExtra("id", 0);
        if (studentid != 0) {
           EditStudentSetValues(studentid);
        }
//GetCourse//
        Retrofit retrofitForCourse = okHttpClientObject.okHttpClientObjectApiCall();
        JsonApiPlaceHolder jsonApiPlaceHolderForCourse= retrofitForCourse.create(JsonApiPlaceHolder.class);
        Call<List<CourseDto>> callForCourse =jsonApiPlaceHolderForCourse.getCourses();
        callForCourse.enqueue(new Callback<List<CourseDto>>() {
            @Override
            public void onResponse(Call<List<CourseDto>> call, Response<List<CourseDto>> response) {
                AllCourseDto = response.body();
                int i = 0;
                String[] newArray = new String[AllCourseDto.size()];
                for (CourseDto course : AllCourseDto) {
                    newArray[i] = course.Name.toString();
                    CoursesWithIds.add(course.CourseId);
                    i++;
                }
                Courses = newArray;
            }
            @Override
            public void onFailure(Call<List<CourseDto>> call, Throwable t) {
                String Error = t.getMessage();
            }
        });
        mOrder =findViewById(R.id.btnOrder);
        mItemSelected=findViewById(R.id.tvItemSelected);
        mOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                checkCourses= new boolean[Courses.length];
                AlertDialog.Builder mBuilder=new AlertDialog.Builder(AddStudent.this);
                mBuilder.setTitle(R.string.clear_label);
                mBuilder.setMultiChoiceItems(Courses, checkCourses, new DialogInterface.OnMultiChoiceClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int position, boolean isChecked) {
                        if (isChecked){
                            if (!userCheckCourses.contains(CoursesWithIds.get(position).intValue())) {
                                userCheckCourses.add(CoursesWithIds.get(position).intValue());
                            } else {
                                userCheckCourses.remove(CoursesWithIds.get(position).intValue());
                            }
                        } else {
                            userCheckCourses.remove(position);
                        }
                    }
                });
                mBuilder.setCancelable(false);
                mBuilder.setPositiveButton(R.string.ok_label, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                    }
                });
                mBuilder.setNegativeButton(R.string.dismiss_label, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int which) {
                        dialogInterface.dismiss();
                    }
                });
                mBuilder.setNeutralButton(R.string.clear_all_label, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        for(int i=0;i<checkCourses.length;i++){
                            checkCourses[i]=false;
                            userCheckCourses.clear();
                            mItemSelected.setText("");
                        }
                    }
                });
                AlertDialog mDialog= mBuilder.create();
                mDialog.show();
            }
        });
        Button submitButton = findViewById(R.id.button);
        submitButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Student student = new Student();
                TextView sName = findViewById(R.id.editTextTextPersonName);
                student.setName(sName.getText().toString());
                TextView sEmail = findViewById(R.id.editTextTextEmailAddress);
                student.setEmail(sEmail.getText().toString());
                TextView sContact = findViewById(R.id.editTextPhone);
                student.setContact(sContact.getText().toString());
                TextView sPassword = findViewById(R.id.editTextTextPassword);
                student.setPassword(sPassword.getText().toString());
                TextView sConfirmPassword = findViewById(R.id.editTextTextPassword2);
                student.setConfirmPassword(sConfirmPassword.getText().toString());
                StudentDto object = new StudentDto();
                object.student = student;
                object.setCoursesList(userCheckCourses);
                postStudent(object);
            }
        });
    }
    //Post Student And Course
    private void postStudent(StudentDto object){
        if(studentid==0){
            Retrofit retrofit = okHttpClientObject.okHttpClientObjectApiCall();
            JsonApiPlaceHolder jsonApiPlaceHolder= retrofit.create(JsonApiPlaceHolder.class);
            Call<List<StudentDto>> call = jsonApiPlaceHolder.postStudent(object);
            call.enqueue(new Callback<List<StudentDto>>() {
                @Override
                public void onResponse(Call<List<StudentDto>> call, Response<List<StudentDto>> response) {
                }
                @Override
                public void onFailure(Call<List<StudentDto>> call, Throwable t) {
                    String Error = t.getMessage();
                }
            });}else{
            //Put  Api for student data//
            object.student.setId(studentid);
            OkHttpClient okHttpClient = UnsafeOkHttpClient.getUnsafeOkHttpClient();
            Retrofit retrofit= new Retrofit.Builder()
                    .baseUrl("https://192.168.1.10:45455/api/")
                    .client(okHttpClient)
                    .addConverterFactory(GsonConverterFactory.create())
                    .build();
            JsonApiPlaceHolder jsonApiPlaceHolder= retrofit.create(JsonApiPlaceHolder.class);
            Call<String> call = jsonApiPlaceHolder.eidtStudent(object.student);
            call.enqueue(new Callback<String>() {
                @Override
                public void onResponse(Call<String>call, Response<String>response) {
                }
                @Override
                public void onFailure(Call<String> call, Throwable t) {
                }
            });
        }
    }
    // Api For Get data for Edit// Get By Id //
    private void EditStudentSetValues(int id){
        Retrofit retrofit = okHttpClientObject.okHttpClientObjectApiCall();
            JsonApiPlaceHolder jsonApiForEditStudent= retrofit.create(JsonApiPlaceHolder.class);
            Call<StudentDto> call = jsonApiForEditStudent.getOneStudent(id);
            call.enqueue(new Callback<StudentDto>() {
                @Override
                public void onResponse(Call<StudentDto> call, Response<StudentDto> response) {
                    StudentDto student = response.body();
                    name = findViewById(R.id.editTextTextPersonName);
                    email= findViewById(R.id.editTextTextEmailAddress);
                    contact = findViewById(R.id.editTextPhone);
                    password= findViewById(R.id.editTextTextPassword);
                    confirmpassword= findViewById(R.id.editTextTextPassword2);
                    name.setText(student.student.getName().toString(), TextView.BufferType.EDITABLE);
                    email.setText(student.student.getEmail().toString(), TextView.BufferType.EDITABLE);
                    contact.setText(student.student.getContact().toString(), TextView.BufferType.EDITABLE);
                    password.setText(student.student.getPassword().toString(), TextView.BufferType.EDITABLE);
                    confirmpassword.setText(student.student.getConfirmPassword().toString(), TextView.BufferType.EDITABLE);
                }
                @Override
                public void onFailure(Call<StudentDto> call, Throwable t) {
                    Log.e("Error", t.getMessage());
                }
            });
        }
    }
