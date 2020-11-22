import React, { Component } from "react";
import 'bootstrap/dist/css/bootstrap.css';
class Calculator extends Component {
  state = {
      result:"",
      calculate:[]
  };
handleChange=(e)=>{
   let value= e.target.getAttribute('value');
   if(value=="ac")
   {     
       this.setState({result:""});
   }else if(value=="equal"){
    this.setState({result:eval(this.state.result)});
   }
   else{
     this.setState({result:this.state.result+value});
    }
}
  render() {
    return (
        <div className="container">
      <div class="calculator card">
        <input
          type="text"
          class="calculator-screen z-depth-1" value={this.state.result} 
          disabled
        />
        <div class="calculator-keys">
          <button type="button" onClick={this.handleChange}  value="+">+</button>
          <button type="button" onClick={this.handleChange}  value="-">-</button>
          <button type="button" onClick={this.handleChange}  value="*">&times;</button>
          <button type="button"  onClick={this.handleChange} value="/">&divide;</button>
          <button type="button"  onClick={this.handleChange} value="7" >7</button>
          <button type="button"  onClick={this.handleChange} value="8" >8</button>
          <button type="button"  onClick={this.handleChange} value="9" >9</button>
          <button type="button"  onClick={this.handleChange} value="4" >4</button>
          <button type="button"  onClick={this.handleChange} value="5" >5</button>
          <button type="button"  onClick={this.handleChange} value="6" >6</button>
          <button type="button"  value="1" onClick={this.handleChange} >1</button>
          <button type="button"  value="2" onClick={this.handleChange} >2</button>
          <button type="button"  value="3" onClick={this.handleChange} >3</button>
          <button type="button" value="0" onClick={this.handleChange} >0</button>

          <button type="button"
           class="decimal function btn btn-secondary" value="." onClick={this.handleChange} >. </button>
          <button type="button"
            class="all-clear function btn btn-danger btn-sm" value="ac"onClick={this.handleChange}>AC</button>
          <button type="button"
            class="equal-sign operator btn btn-default" value="equal" onClick={this.handleChange} >= </button>
        </div>
      </div>
      </div>
    );
  }
}
export default Calculator;