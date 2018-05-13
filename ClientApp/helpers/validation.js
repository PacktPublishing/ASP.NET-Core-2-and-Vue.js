import axios from "axios";
import { Validator } from "vee-validate";

const isUnique = value =>
  new Promise(resolve => {
    const payload = { name: value };

    axios.post("/api/products/validate", payload).then(response => {
      const isValid = response.data;
      if (isValid) {
        return resolve({
          valid: true
        });
      } else {
        return resolve({
          valid: false,
          data: {
            message: "Name is already in use."
          }
        });
      }
    });
  });

Validator.extend("uniqueProductName", {
  validate: isUnique,
  getMessage: (field, params, data) => data.message
});
