import React, { useState, useContext } from "react";
import {
  Table,
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
} from "reactstrap";
import { PenFill, TrashFill, PlusCircleFill } from "react-bootstrap-icons";
import { Link } from "react-router-dom";
import {CategoryData} from "../../data/categoryData";

const Category = () => {
  const [modal, setModal] = useState(false);

  const toggle = () => setModal(!modal);

  const { categoryItems } = useContext(CategoryData);

  return (
    <>
      <h2 className="text-center p-3">Category</h2>
      <div style={{ float: "right" }}>
      <Button color="success" className="mb-2 ml-2">
        <PlusCircleFill color="white" size={20} className="mr-2" />
        <Link to="/categoryform" className="text-decoration-none text-white">
        {" "}New Category
        </Link>
      </Button>
      </div>
      <Table striped className="text-center">
        <thead>
          <tr>
            <th>Image</th>
            <th>Name</th>
            <th>Description</th>
            <th>Edit / Delete</th>
          </tr>
        </thead>
        <tbody>
          {categoryItems &&
            categoryItems.map((category) => (
              <tr key={category.categoryId}>
                <td>
                  <img
                    src={category.images}
                    alt={category.nameCategory}
                    width="120px"
                    height="120px"
                  ></img>
                </td>
                <td>{category.nameCategory}</td>
                <td>{category.description}</td>
                <td>
                  <Button color="secondary" className="mr-2">
                    <Link to="/categoryform">
                      <PenFill color="white" size={18} />
                    </Link>
                  </Button>{" "}
                  <Button color="danger" className="mr-2">
                    <TrashFill color="white" size={18} onClick={toggle} />
                  </Button>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>

      <div>
        <Modal isOpen={modal} toggle={toggle}>
          <ModalHeader toggle={toggle}>Delete</ModalHeader>
          <ModalBody>Do you want to delete this category ?</ModalBody>
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
export default Category;
