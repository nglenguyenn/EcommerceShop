import React, { useContext } from "react";
import { InputGroup, Input, Button, Container } from "reactstrap";
import { Link } from "react-router-dom";
import { useFormik } from "formik";
import { ProductData } from "../../data/productData";

const initialValues = {
  name: "",
  description: "",
  price: 0,
  categoryId: "",
  images: null,
};

const ProductForm = () => {
  const { categoryItems, postProduct } = useContext(ProductData);

  const formik = useFormik({
    initialValues,
    onSubmit: (values, actions) => {
      actions.setSubmitting(true);
      setTimeout(() => {
        var formData = new FormData();
        Object.keys(values).forEach((key) => {
          formData.append(key, values[key]);
        });
        postProduct(formData);
        actions.setSubmitting(false);
      }, 1000);
    },
  });
  return (
    <>
      <h2 className="text-center p-3">Product Form</h2>
      <div>
        <form onSubmit={formik.handleSubmit}>
          <Container>
            <InputGroup>
              <Input
                name="name"
                value={formik.values.name}
                onChange={formik.handleChange}
                placeholder="Name"
              />
            </InputGroup>
            <br />
            <InputGroup>
              <Input
                name="description"
                value={formik.values.description}
                onChange={formik.handleChange}
                placeholder="Description"
              />
            </InputGroup>
            <br />
            <InputGroup>
              <Input
                name="price"
                type="number"
                value={formik.values.price}
                onChange={formik.handleChange}
                placeholder="Price"
              />
            </InputGroup>
            <br />
            <InputGroup>
              <Input
                type="select"
                name="categoryId"
                value={formik.values.categoryId}
                onChange={formik.handleChange}
              >
                {categoryItems &&
                  categoryItems.map((category) => (
                    <option value={category.categoryId}>
                      {category.nameCategory}
                    </option>
                  ))}
              </Input>
            </InputGroup>
            <br />
            <InputGroup>
              <input
                name="images"
                type="file"
                onChange={(event) => {
                  formik.setFieldValue("images", event.currentTarget.files[0]);
                }}
              />
            </InputGroup>
            <br />
            <div className="text-center">
              <Button color="secondary" className="mr-2">
                <Link
                  to="/products"
                  className="text-decoration-none text-white"
                >
                  Close
                </Link>
              </Button>{" "}
              <Button
                disabled={formik.isSubmitting}
                type="submit"
                color="success"
              >
                Submit
              </Button>{" "}
            </div>
          </Container>
        </form>
      </div>
    </>
  );
};

export default ProductForm;
