import './App.css';
import Help from './Help';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Form from './Form';

function App() {
  return (
    <div >
      <BrowserRouter>
        <Switch>
          <Route path='/help' exact>
          <Help/>
          </Route>
          <Route path='/' exact>
           <Form/>
          </Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
