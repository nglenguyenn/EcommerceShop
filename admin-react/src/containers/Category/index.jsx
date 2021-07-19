import React from 'react';
import { Table, Button } from 'reactstrap';
import { PenFill, TrashFill, PlusCircleFill } from 'react-bootstrap-icons';

const Category = () => {
  return (
    <>
      <h2 className="text-center p-3">Category</h2>
      <div style={{float: 'right'}}>
      <Button color="success" className="mb-2 ml-2"><PlusCircleFill color="white" size={20} className="mr-2"/> Create new category</Button>
      </div>
      <Table striped className="text-center">
        <thead>
          <tr>
            <th>Image</th>
            <th>Name</th>
            <th>Description</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <img src="./Apple.png" width="150px" height="150px"></img>
            </td>
            <td>Apple</td>
            <td>Description of Apple</td>
            <td>
              <Button color="secondary" className="mr-2"><PenFill color="white" size={20} /></Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
          <tr>
            <td>
              <img src="./Sony.png" width="150px" height="150px"></img>
            </td>
            <td>Sony</td>
            <td>Description of Sony</td>
            <td>
              <Button color="secondary" className="mr-2"><PenFill color="white" size={20} /></Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
          <tr>
            <td>
              <img src="./Samsung.png" width="150px" height="150px"></img>
            </td>
            <td>SamSung</td>
            <td>Description of SamSung</td>
            <td>
              <Button color="secondary" className="mr-2"><PenFill color="white" size={20} /></Button>
              <Button color="danger" className="mr-2"><TrashFill color="white" size={20} /></Button>
            </td>
          </tr>
        </tbody>
      </Table>
    </>
  );
}
export default Category;