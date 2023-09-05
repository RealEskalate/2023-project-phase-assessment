import { useGetDoctorDetailsQuery } from "@/store/features/doctor-api";
import { useParams } from "next/navigation";

export default function DoctorsDetails() {
  const { id } = useParams();
  const {
    data: detail,
    isLoading,
    isError,
    isSuccess,
    error,
  } = useGetDoctorDetailsQuery(id);
  let content;
  if (isLoading) {
    content = <div>loading</div>;
  } else if (isError) {
    content = <div>error</div>;
  } else if (isSuccess) {
    content = (
      <div>
        <div>{detail.fullName}</div>
        <img src={detail.photo} />
        <div>{detail.speciality}</div>
        <div>contact info</div>
        <div>{detail.emails}</div>
      </div>
    );
  }

  return <>{content}</>;
}
