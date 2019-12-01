import React, { Component } from 'react';  //NOTE: need to import '{Component}'
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

class App extends Component {  //NOTE: Compoent declaration. 
  state={
    values: []
  }
  componentDidMount(){
    axios.get('http://localhost:5000/api/values').then(response => {
      this.setState({
        values: response.data
      });
    });   
  }
  render() {
    return (
      <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          {this.state.values.map((value: any) => (  //NOTE: MUST declare value to :any type, otherwise compilation error. 
            <li key={value.id}>{value.name}</li>
          ))}
        </ul>
      </header>
    </div>   
    );  
  }
}
export default App;
