import React, { useState } from "react";
import {
  Table,
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
} from "reactstrap";
import {
  StarFill,
  PenFill,
  TrashFill,
  PlusCircleFill,
} from "react-bootstrap-icons";
import { Link } from "react-router-dom";

const Product = () => {
  const [modal, setModal] = useState(false);

  const toggle = () => setModal(!modal);

  return (
    <>
      <h2 className="text-center p-3">Product</h2>
      <div style={{ float: "right" }}>
        <Button color="success" className="mb-2 ml-2">
          <PlusCircleFill color="white" size={20} className="mr-2" />
          <Link to="/productform" className="text-decoration-none text-white">
            New Product
          </Link>
        </Button>
      </div>
      <Table striped className="text-center">
        <thead>
          <tr>
            <th>Image</th>
            <th>Name</th>
            <th>Description</th>
            <th>Price</th>
            <th>Category</th>
            <th>Rating</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <img
                src="./Iphone12promax .jpg"
                width="150px"
                height="150px"
              ></img>
            </td>
            <td>Iphone 12 Pro Max</td>
            <td>Description of Iphone 12 Pro Max</td>
            <td>29.990.000 VND</td>
            <td>Macbook</td>
            <td>
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
            </td>
            <td>
              <Button color="secondary" className="mr-2">
                <Link to="/productform">
                  <PenFill color="white" size={20} />
                </Link>
              </Button>
              <Button color="danger" className="mr-2">
                <TrashFill color="white" size={20} onClick={toggle} />
              </Button>
            </td>
          </tr>
          <tr>
            <td>
              <img
                src="./Iphone11promax .jpg"
                width="150px"
                height="150px"
              ></img>
            </td>
            <td>Iphone 11 Pro Max</td>
            <td>Description of Iphone 11 Pro Max</td>
            <td>19.990.000 VND</td>
            <td>Macbook</td>
            <td>
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
              <StarFill color="#ffdd59" size={20} />
            </td>
            <td>
              <Button color="secondary" className="mr-2">
                <Link to="/productform">
                  <PenFill color="white" size={20} />
                </Link>
              </Button>
              <Button color="danger" className="mr-2">
                <TrashFill color="white" size={20} onClick={toggle} />
              </Button>
            </td>
          </tr>
        </tbody>
      </Table>
      <div>
        <Modal isOpen={modal} toggle={toggle}>
          <ModalHeader toggle={toggle}>Delete</ModalHeader>
          <ModalBody>Do you want to delete this product ?</ModalBody>
          <ModalFooter>
            <Button color="secondary" onClick={toggle}>
              No
            </Button>{" "}
            <Button color="danger" onClick={toggle}>
              Yes
            </Button>{" "}
          </ModalFooter>
        </Modal>
      </div>
    </>
  );
};
export default Product;
