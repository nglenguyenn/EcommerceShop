import React from 'react';
import { InputGroup, InputGroupAddon, InputGroupText, Input, Button, Container } from 'reactstrap';
import * as Icon from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

const ProductForm = () => {
    return (
        <>
            <h2 className="text-center p-3">Product Form</h2>
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
                        <Input placeholder="Price" />
                    </InputGroup>
                    <br />
                    <InputGroup>
                        <Input placeholder="Category" />
                    </InputGroup>
                    <br />
                    <InputGroup>
                        <Input type="file" />
                    </InputGroup>
                    <br />
                    <div className="text-center">
                        <Button color="secondary" className="mr-2">
                            <Link to="/products" className="text-decoration-none text-white">Close</Link>
                        </Button>{' '}
                        <Button color="success">Submit</Button>{' '}
                    </div>
                </Container>
            </div>
        </>
    );
}

export default ProductForm; 