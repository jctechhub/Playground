import React, { Component } from 'react';  //NOTE: need to import '{Component}'
import './App.css';
import axios from 'axios';
import { Header, Icon, List } from 'semantic-ui-react'

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
      <div>
       <Header as='h2'>
        <Icon name='users' />
        <Header.Content>Reactivities</Header.Content>
      </Header>
      <List>
        {this.state.values.map((value: any) => (  //NOTE: MUST declare value to :any type, otherwise compilation error. 
            <List.Item key={value.id}> {value.name}</List.Item>
          ))}
      </List>      
      
    </div>   
    );  
  }
}
export default App;
