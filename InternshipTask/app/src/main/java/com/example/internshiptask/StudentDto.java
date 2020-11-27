package com.example.internshiptask;


import java.util.List;

public class StudentDto {
    public Student student;

    public Student getStudent() {
        return student;
    }

    public void setStudent(Student student) {
        this.student = student;
    }

    public List<Integer> getCoursesList() {
        return CoursesList;
    }

    public void setCoursesList(List<Integer> coursesList) {
        CoursesList = coursesList;
    }

    public List<Integer> CoursesList;
}
