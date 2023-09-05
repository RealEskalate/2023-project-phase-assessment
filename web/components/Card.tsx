interface CardProps {
  _id: string;
  fullName: string;
  speciality?: [name: string];
  institutionID_list?: [institutionName: string];
  photo: string;
}
export default function Card({
  _id,
  fullName,
  speciality,
  institutionID_list,
  photo,
}: CardProps) {
  return (
    <div className="w-[19.25rem] h-[16.125rem]">
      {/* <div className="relative">
        <div className="absolute inset-x-0 bottom-0 h-1/2 bg-red-500 z-10"></div>
        <div className="h-24 bg-blue-500">Parent</div>
      </div> */}

      <div>
        <img className="" src={photo} alt="profile-picture" />
      </div>
      <div>{fullName}</div>
      <div>{speciality}</div>
      <div>{institutionID_list}</div>
    </div>
  );
}
