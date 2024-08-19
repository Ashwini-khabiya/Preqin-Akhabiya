import React, { useState } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import '../css/NavMenu.css';

function NavMenu() {

    const [isCollapsed, setCollapsed] = useState(true);

    const toggleNavbar = () => {
        setCollapsed(!isCollapsed);
    };

    return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
                    container light>
                    <NavbarBrand tag={Link} to="/">Preqin</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={isCollapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                               <NavLink tag={Link} className="text-dark" to="/investor">Investors</NavLink>
                            </NavItem>
                            {/*<NavItem>*/}
                            {/*    <NavLink tag={Link} className="text-dark" to="/commitments">Commitments</NavLink>*/}
                            {/*</NavItem>*/}
                        </ul>
                    </Collapse>
                </Navbar>
            </header>
    );
}
export default NavMenu;