import React, { Component } from 'react';  //NOTE: need to import '{Component}'
import logo from './logo.svg';
import './App.css';

class App extends Component {  //NOTE: Compoent declaration. 
  state={
    values: []
  }
  componentDidMount(){
    this.setState({
      values: [{id: 1, name: "value 101"}, {id:2, name: "value 102"}]
    })
  }
  render() {
    return (
      <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          {this.state.values.map((value: any) => (  //NOTE: MUST declare value to :any type, otherwise compilation error. 
            <li>{value.name}</li>
          ))}
        </ul>
      </header>
    </div>   
    );  
  }
}
export default App;
