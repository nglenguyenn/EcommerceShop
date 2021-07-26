import { useContext, useState } from 'react';
import { Table, Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { PenFill, TrashFill, PlusCircleFill } from "react-bootstrap-icons";
import { Link } from "react-router-dom";
import { CategoryData } from "../../data/categoryData";

const Category = () => {
  const { categoryItems, deleteCategory } = useContext(CategoryData);
  const [categoryId, setCategoryId] = useState("");

  const [modal, setModal] = useState(false);

  const handleClose = () => {
    setModal(false);
    setCategoryId("");
  }

  const handleShow = (props) => {
    setModal(true);
    setCategoryId(props);
  }

  const deleteCate = (props) => {
    deleteCategory(props)
    setModal(false);
    setCategoryId("");
  }
  return (
    <>
      <h2 className="text-center p-3">Category</h2>
      <div style={{ float: "right" }}>
        <Button color="success" className="mb-2 ml-2">
          <PlusCircleFill color="white" size={20} className="mr-2" />
          <Link
            to={{
              pathname: "/categoryform",
              categoryId: "",
              category: {
                nameCategory: "",
                description: "",
                images: null,
              },
            }}
            className="text-decoration-none text-white"
          >
            {" "}
            New Category
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
                    <Link
                      to={{
                        pathname: "/categoryform",
                        categoryId: category.categoryId,
                        category: {
                          nameCategory: category.nameCategory,
                          description: category.description,
                          images: null,
                        },
                      }}
                    >
                      <PenFill color="white" size={18} />
                    </Link>
                  </Button>{" "}
                  <Button
                    color="danger"
                    className="mr-2"
                    onClick={() => handleShow(category.categoryId)}
                  >
                    <TrashFill color="white" size={18} />
                  </Button>
                </td>
              </tr>
            ))}
        </tbody>
      </Table>
      <Modal isOpen={modal}>
        <ModalHeader>Delete category</ModalHeader>
        <ModalBody>
          Are you sure delete this category ?
           </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={handleClose}>Close</Button>{' '}
          <Button color="danger" onClick={() => deleteCate(categoryId)}>Delete</Button>
        </ModalFooter>
      </Modal>
    </>
  );
};
export default Category;
