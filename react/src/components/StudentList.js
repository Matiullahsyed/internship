import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import {Link} from 'react-router-dom';
export class StudentList  extends Component {
    state = {  }
    render() { 
        const {dataFromapi}=this.props;
        return ( 
        <table className="table">
            <thead>
            <React.Fragment>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Contact number</th>
                    <th>Password</th>
                    <th>Confirm Password</th>
                    <th>Course</th>
                    <th></th>
                </tr>
               </React.Fragment>
            </thead>
            <React.Fragment>
            <tbody>
            {this.props.dataFromapi.map((row) => (
            <tr key={row.student.Id}>
                    <td>{row.student.Name}</td>
                    <td>{row.student.Email}</td>
                    <td>{row.student.Contact}</td>
                    <td>{row.student.Password}</td>
                    <td>{row.student.ConfirmPassword}</td>
                    <td>{row.CoursesCount}</td>
                    <td> <button  
                         className="btn btn-warning btn-sm m-2"><Link to="/form">Edit</Link></button>
                         <button  onClick={()=>this.props.onDelete(row.student.Id)} 
                         className="btn btn-danger btn-sm">Delete</button>
                    </td>
            </tr>
                ))}
            </tbody>
            </React.Fragment>
        </table>
        );
    }
}
export default StudentList;