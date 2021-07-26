import RequestService from "../services/request";
import { Backend_url } from "../config";

const product_url = Backend_url + "/api/products";

export const GetProducts = () => {
    return RequestService.axios.get(product_url)
      .then(response => response.data)
      .catch((error) => {
          console.log(error.response);
          return [];
      });
};

export const PostProduct = (formData) => {
    return RequestService.axios({
      method: "post",
      url: product_url,
      data: formData,
  })
      .then((response) => {
          return response.data;
      })
      .catch((error) => {
          console.log(error.response);
          return null;
      });
};

export const PutProduct = (id, formData) => {
    return RequestService.axios({
      method: "put",
      url: product_url + '/' + id,
      data: formData,
  })
      .then((response) => {
          return response.data;
      })
      .catch((error) => {
          console.log(error.response);
          return null;
      });
};

export const DeleteProduct = (id) => {
    return RequestService.axios({
      method: "delete",
      url: product_url + '/' + id,
  })
      .then((response) => {
          return response.data;
      })
      .catch((error) => {
          console.log(error.response);
          return null;
      });
};

