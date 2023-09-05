import { Pulsar } from "@uiball/loaders";
import React from "react";

const loading = () => {
  return (
    <div className="w-full h-96 flex justify-center items-center">
      <Pulsar size={35} color="#231F20" />
    </div>
  );
};

export default loading;
