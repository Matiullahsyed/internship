package com.example.internshiptask;
public class Student {
    private int Id;
    private String Name;
    private String Email;
    private String Contact;
    private String Password;
    private String ConfirmPassword;

    public void setId(int id) {
        Id = id;
    }
    public void setName(String name) {
        Name = name;
    }
    public void setEmail(String email) {
        Email = email;
    }
    public void setContact(String contact) {
        Contact = contact;
    }
    public void setPassword(String password) {
        Password = password;
    }
    public void setConfirmPassword(String confirmPassword) {
        ConfirmPassword = confirmPassword;
    }
    public int getId() {
        return Id;
    }
    public String getName() {
        return Name;
    }
    public String getEmail() {
        return Email;
    }
    public String getContact() {
        return Contact;
    }
    public String getPassword() {
        return Password;
    }
    public String getConfirmPassword() {
        return ConfirmPassword;
    }
}
