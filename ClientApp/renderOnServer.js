process.env.VUE_ENV = "server";

const fs = require("fs");
const path = require("path");

const filePath = path.join(__dirname, "../wwwroot/dist/main-server.js");
const code = fs.readFileSync(filePath, "utf8");

const bundleRenderer = require("vue-server-renderer").createBundleRenderer(
  code
);

var prerendering = require("aspnet-prerendering");
module.exports = prerendering.createServerRenderer(function(params) {
  return new Promise(function(resolve, reject) {
    const context = {
      url: params.url,
      absoluteUrl: params.absoluteUrl,
      baseUrl: params.baseUrl,
      data: params.data,
      domainTasks: params.domainTasks,
      location: params.location,
      origin: params.origin,
      cookies: params.data.cookies
    };

    bundleRenderer.renderToString(context, (err, _html) => {
      if (err) {
        reject(err.message);
      }
      resolve({
        globals: {
          html: _html,
          __INITIAL_STATE__: context.state
        }
      });
    });
  });
});
