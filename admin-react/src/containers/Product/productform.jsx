import { useContext } from "react";
import {
  InputGroup,
  InputGroupAddon,
  Input,
  Button,
  Container,
} from "reactstrap";
import { Link, useHistory } from "react-router-dom";
import { useFormik } from "formik";
import { ProductData } from "../../data/productData";
import { Img } from "../../utils/image";

const ProductForm = (props) => {
  let history = useHistory();

  const productId = props.location.productId;
  const initialValues = props.location.product;

  const { categoryItems, postProduct, putProduct } = useContext(ProductData);

  const formik = useFormik({
    initialValues,
    onSubmit: (values, actions) => {
      actions.setSubmitting(true);
      setTimeout(() => {
        var formData = new FormData();

        Object.keys(values).forEach((key) => {
          formData.append(key, values[key]);
        });

        if (productId === "") {
          postProduct(formData);
        } else {
          putProduct(productId, formData);
        }

        actions.setSubmitting(false);

        history.push("/product");
      }, 1000);
    },
  });

  return (
    <>
      <h2 className="text-center p-3">Product</h2>
      <div>
        <form onSubmit={formik.handleSubmit}>
          <Container>
            <InputGroup>
              <InputGroupAddon addonType="prepend"></InputGroupAddon>
              <Input
                name="name"
                value={formik.values.name}
                onChange={formik.handleChange}
                placeholder="Name"
              />
            </InputGroup>
            <br />
            <InputGroup>
              <InputGroupAddon addonType="prepend"></InputGroupAddon>
              <Input
                name="description"
                value={formik.values.description}
                onChange={formik.handleChange}
                placeholder="Description"
              />
            </InputGroup>
            <br />
            <InputGroup>
              <InputGroupAddon addonType="prepend"></InputGroupAddon>
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
              <InputGroupAddon addonType="prepend"></InputGroupAddon>
              <Input
                type="select"
                name="categoryId"
                value={formik.values.categoryId}
                onChange={formik.handleChange}
              >
                {categoryItems &&
                  categoryItems.map((category) => (
                    <option selected value={category.categoryId}>
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
            <Img file={formik.values.images} />
            <br />
            <div className="text-center m-3">
              <Button color="secondary" className="mr-2" type="button">
                <Link to="/product" className="text-decoration-none text-white">
                  Close
                </Link>
              </Button>{" "}
              <Button
                disabled={formik.isSubmitting}
                type="submit"
                color="success"
              >
                Submit
              </Button>
            </div>
          </Container>
        </form>
      </div>
    </>
  );
};

export default ProductForm;
