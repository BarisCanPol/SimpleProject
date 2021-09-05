import logo from './logo.svg';
import './App.css';

import {Home} from './Home';
import { Deparment } from './Department';
import {Employee} from './Employee';
import {Navigation} from './Navigation';
import moment from 'moment';
//For routing
import {BrowserRouter,Route,Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center"> 
React Js Tutorial
      </h3>
      <Navigation/>

    <Switch>
    <Route path="/" component={Home} exact/>
      <Route path="/department" component={Deparment}/>
      <Route path="/employee" component={Employee}/>    
    </Switch>
    </div>
    
    </BrowserRouter>

    
  );
}

export default App;
