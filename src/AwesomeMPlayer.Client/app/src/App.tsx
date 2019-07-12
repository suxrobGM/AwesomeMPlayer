import React from 'react';
import { Layout } from './components/Layout';
import { Card, CardBody } from 'reactstrap';
import { LoginForm } from './components/LoginForm';
//import './App.css';

const App: React.FC = () => {
  return (
    <div className="App">
      <Layout>
        <Card className="my-auto mx-auto col-9 col-md-6">
          <CardBody>
            <LoginForm />
          </CardBody>
        </Card>
      </Layout>
    </div>
  );
}

export default App;
