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

import { CategoryData } from "../../data/categoryData";
import { Img } from "../../utils/image";

const CategoryForm = (props) => {
  let history = useHistory();

  const categoryId = props.location.categoryId;
  const initialValues = props.location.category;

  const { postCategory, putCategory } = useContext(CategoryData);

  const formik = useFormik({
    initialValues,
    onSubmit: (values, actions) => {
      actions.setSubmitting(true);
      setTimeout(() => {
        var formData = new FormData();

        Object.keys(values).forEach((key) => {
          formData.append(key, values[key]);
        });

        if (categoryId === "") {
          postCategory(formData);
        } else {
          putCategory(categoryId, formData);
        }

        actions.setSubmitting(false);

        history.push("/category");
      }, 1000);
    },
  });

  return (
    <>
      <h2 className="text-center p-3">Category</h2>
      <div>
        <form onSubmit={formik.handleSubmit}>
          <Container>
            <InputGroup>
              <InputGroupAddon addonType="prepend"></InputGroupAddon>
              <Input
                name="nameCategory"
                value={formik.values.nameCategory}
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
              <input
                name="thumbnailImages"
                type="file"
                onChange={(event) => {
                  formik.setFieldValue(
                    "thumbnailImages",
                    event.currentTarget.files[0]
                  );
                }}
              />
            </InputGroup>
            <Img file={formik.values.images} />
            <br />
            <div className="text-center">
              <Button color="secondary" className="mr-2" type="button">
                <Link
                  to="/category"
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
              </Button>
            </div>
          </Container>
        </form>
      </div>
    </>
  );
};

export default CategoryForm;
