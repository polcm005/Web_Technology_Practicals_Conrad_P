import logo from './logo.svg';
import './App.css';
import { Link, Outlet } from "react-router-dom";
import Card from './components/Card';
import CardV2 from './components/CardV2';
import CardV3 from './components/CardV3';
import CardListSearch from './components/CardListSearch';

function App() {
  return (
      <div className="App container">
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
              <div className="container-fluid">
                  <Link className="navbar-brand" to="/">AOWebApp</Link>
                  <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                      <span className="navbar-toggler-icon"></span>
                  </button>
                  <div className="collapse navbar-collapse" id="navbarNav">
                      <ul className="navbar-nav">
                          <li className="nav-item">
                              <Link className="nav-link active" to="/Home">Home</Link>
                          </li>
                          <li className="nav-item">
                              <Link className="nav-link" to="/Contact">Contact</Link>
                          </li>
                          <li className="nav-item">
                              <Link className="nav-link" to="/Products">Products</Link>
                          </li>
                      </ul>
                  </div>
              </div>
          </nav>
          <Outlet />

            {/*<div className="bg-light py-1 mb-2">*/}
            {/*    <h2 className="text-center">Example application</h2>*/}
            {/*</div>*/}

            {/*<div className="row justify-content-center">*/}
            {/*  <Card ItemID="1"*/}
            {/*          itemName="test record1"*/}
            {/*          itemDescription="test record1 description"*/}
            {/*          itemImage="https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg"*/}
            {/*          itemCost="15.00"*/}
            {/*  />*/}
            {/*  <CardV2 ItemID="2"*/}
            {/*      itemName="test record2"*/}
            {/*      itemDescription="test record2 description"*/}
            {/*      itemImage="https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg"*/}
            {/*      itemCost="15.00"*/}
            {/*  />*/}
            {/*  <CardV3 ItemID="3"*/}
            {/*      itemName="test record3"*/}
            {/*      itemDescription="test record3 description"*/}
            {/*      itemImage="https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg"*/}
            {/*      itemCost="15.00"*/}
            {/*  />*/}

            {/*      <CardListSearch />*/}
             
            {/*</div>*/}

            {/*<img src={logo} className="App-logo" alt="logo" />*/}
            {/*<p>*/}
            {/*          Edit <code>src/App.js</code> and save to reload.*/}
            {/*  Change made*/}
            {/*</p>*/}
            {/*<a*/}
            {/*  className="App-link"*/}
            {/*  href="https://reactjs.org"*/}
            {/*  target="_blank"*/}
            {/*  rel="noopener noreferrer"*/}
            {/*>*/}
            {/*  Learn React*/}
            {/*      </a>*/}
            {/*<h2 className="text-centre">example application</h2>*/}
      </div>
  );
}

export default App;
