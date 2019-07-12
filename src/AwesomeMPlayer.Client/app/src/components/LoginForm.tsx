import React, { FormEvent } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import { UserCredentials } from '../models/UserCredentials';

export class LoginForm extends React.Component<{}, UserCredentials> {
    
    constructor(props: Readonly<{}>) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleSubmit(e: FormEvent) {
        e.preventDefault(); 

        // eslint-disable-next-line
        let emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        let re = new RegExp(emailPattern);
        let username = String(this.state.username);
        console.log(username);
        let isEmail = re.test(username);
        console.log(isEmail);

        if(isEmail)
            this.setState({usernameIsEmail: true});

        fetch('https://localhost:5001/api/auth', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json;charset=utf-8',
            },
            body: JSON.stringify(this.state)
        })
        .then(res => console.log(res))
        .catch(err => console.log(err));
    }

    handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        let name = e.currentTarget.name;
        let value = e.currentTarget.value;
        this.setState({[name]: value});
    }

    render() {
        return (
            <Form onSubmit={this.handleSubmit}>
                <FormGroup>
                    <Label>Username or email</Label>
                    <Input type="text" name="username" onChange={this.handleChange} required />
                </FormGroup>
                <FormGroup>
                    <Label>Password</Label>
                    <Input type="password" name="password" onChange={this.handleChange} required />
                </FormGroup>
                <Button color="danger" type="submit" value="Sign In">Sign In</Button>
            </Form>                
        );
    }
}