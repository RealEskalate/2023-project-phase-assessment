import DoctorDetail from "@/components/Detail/DoctorDetail";
import React from "react";

export default function page({ params }: { params: { id: string } }) {
  const _id = params.id;
  return (
    <div>
      <div>
        <DoctorDetail id={_id} />
      </div>
    </div>
  );
}
