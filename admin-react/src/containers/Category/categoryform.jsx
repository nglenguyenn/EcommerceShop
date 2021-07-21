import React from 'react';
import { InputGroup, Input, Button, Container } from 'reactstrap';
import { Link } from 'react-router-dom';

const CategoryForm = () => {
    return (
        <>
            <h2 className="text-center p-3">Category Form</h2>
            <div>
                <Container>
                    <InputGroup>                       
                        <Input placeholder="Name" />
                    </InputGroup>
                    <br />
                    <InputGroup>
                        <Input placeholder="Description" />
                    </InputGroup>
                    <br />
                    <InputGroup>
                        <Input type="file" />
                    </InputGroup>
                    <br />
                    <div className="text-center">
                        <Button color="secondary" className="mr-2">
                            <Link to="/categories" className="text-decoration-none text-white">Close</Link>
                        </Button>{' '}
                        <Button color="success">Submit</Button>{' '}
                    </div>
                </Container>
            </div>
        </>
    );
}

export default CategoryForm; 