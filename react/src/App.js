import React, { Component } from 'react';
import './App.css';
import StudentList from './components/StudentList';
import axios from 'axios';
import {BrowserRouter,Route , Redirect,Link} from 'react-router-dom';
import Form from "./components/Form";
import Calculater from "./components/Calculater";
class App extends Component {
  state = { 
    students:[]
   };
   async componentDidMount(){
     const {data:students}= await axios.get("https://localhost:44386/api/student");
     this.setState({students});
   }
   handleDeleteStudent=(id) => {
    axios.delete(`https://localhost:44386/api/student/${id}`)
    .then(res=> {
      this.setState({students:[...this.state.students.filter(std=>std.student.Id
        !==id)]});
        let state = this.state;
    });
    }
  render() { 
    if(this.state.redirect) return <Redirect to={this.state.redirect}/>;
    return ( 
      <BrowserRouter>
       <React.Fragment>
        <button className="btn btn-primary btn-sm m2"><Link to="/form">Add Student Data</Link></button>
        <button className="btn btn-primary btn-sm m2"><Link to="/calculater">Calculater</Link></button>
        <Route path="/calculater" component={Calculater}/>
        <Route path="/form" component={Form}/>
        <Route path="/" exact render={(props)=>
        <StudentList dataFromapi={this.state.students}
        onDelete={this.handleDeleteStudent}
        {...props}/>}/>
       </React.Fragment>
      </BrowserRouter>
     );
  }
}
export default App;
