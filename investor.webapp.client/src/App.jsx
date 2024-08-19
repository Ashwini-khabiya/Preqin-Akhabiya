import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
//import AppRoutes from ' /AppRoutes';
import NavMenu from './components/NavMenu'
import Home from './components/Home';
//import ' /custom.css';
import InvestorDetails from './components/InvestorDetails';
import AssetClassDetails from './components/AssetClassDetails';
//import Commitments from './components/Commitments';

const App = () => {
    return(
        <div>
            <BrowserRouter>
                <NavMenu/>
                <Routes>
                    <Route path= '/' element={<Home />} />
                    <Route path= '/investor' element={<InvestorDetails/>}></Route>
                    <Route path='/investor/:id' element={<AssetClassDetails />}/>
                </Routes>
            </BrowserRouter>        
        </div>
  );
}
export default App;