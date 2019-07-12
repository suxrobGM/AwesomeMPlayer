import React from 'react';
import { Topbar } from './Topbar';
import { Footer } from './Footer';
import { Container } from 'reactstrap';
import './Layout.css';

export class Layout extends React.Component {
    render() {
        return (
            <React.Fragment>
                <Topbar />
                <Container className="main">
                    {this.props.children}
                </Container>
                <Footer />
            </React.Fragment>           
        );
    };
}