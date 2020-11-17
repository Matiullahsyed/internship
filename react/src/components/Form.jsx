import React, { Component } from 'react';
import axios from 'axios';
import Select from 'react-select';

class Form extends Component {
    state = { 
      student: {name:'',email:'',contact:'',password:'',confirmpassword:'',CoursesList:[]},
    courses:[],
    }
      handleSubmit= e=>{
        e.preventDefault();
      }
      handleChange=({currentTarget:input})=>{
        const student={...this.state.student};
        student[input.name]=input.value;
        this.setState({student});
      }
      handleCoursesOnChange =(e)=>{
        this.setState(prevState => {
          let student = Object.assign({}, prevState.student);  
          student.CoursesList = e;                                      
          return ({student });                                 
        });
      }
      async componentDidMount(){
        const {data:courses}= await axios.get("https://localhost:44386/api/course");
        console.log(courses);
        courses.map((course) => {
          const option = { value: course.CourseId, label: course.Name };
          this.setState({
            courses: [...this.state.courses, option],
          });
        });
      }
      saveData=()=>{
      let courses = []; 
      this.state.student.CoursesList.forEach(courseOption => {
        courses.push(courseOption.value);
      })
        axios({
          method: "POST",
          url: "https://localhost:44386/api/student",
          data: {
            Name :  this.state.student.name,
            Email:this.state.student.email,
            Contact:this.state.student.contact,
            Password:this.state.student.password,
            ConfirmPassword:this.state.student.confirmpassword,
            Student: this.state.student,
            CoursesList : courses
          },
            crossdomain: true,
          }).then((res) => {
            console.log(res);
            window.location.reload();
          });
        };
    render() { 
      const {student}=this.state;
        return ( 
        <React.Fragment>
          <div>
            <h1>Enter Student Data</h1>
            <form onSubmit={this.handleSubmit}>
              <div className="form-group">
                <label htmlFor="name">Name</label>
                <input value={student.name} name="name"
                onChange={this.handleChange}
                id="name" type="text" className="form-control"/>
                </div>
              <div className="form-group">
                <label htmlFor="email">Email</label>
                <input value={student.email} name="email"
                onChange={this.handleChange}
                id="email" type="text" className="form-control"/>
                </div>
              <div className="form-group">
                <label htmlFor="contact">Contact#</label>
                <input value={student.contact} name="contact"
                onChange={this.handleChange}
                id="contact" type="text" className="form-control"/>
                </div>
              <div className="form-group">
                <label htmlFor="password">Password</label>
                <input value={student.password} name="password"
                onChange={this.handleChange}
                id="password" type="text" className="form-control"/>
                </div>
              <div className="form-group">
                <label htmlFor="cofirmpassword">Confirm Password</label>
                <input value={student.confirmpassword} name="confirmpassword"
                onChange={this.handleChange}
                id="cofirmpassword" type="text" className="form-control"/>
                </div>
              <div className="form-group">
                <label htmlFor="">Course</label>
                <Select
                  closeMenuOnSelect={false}
                  options={this.state.courses}
                  isMulti
                  onChange={this.handleCoursesOnChange}
                />
                </div>
                <button onClick={()=>this.saveData()} className="btn btn-primary">Submit</button>
            </form>
          </div>
        </React.Fragment>
         );
    }
}
export default Form;