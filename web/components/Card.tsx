export default function Card() {
  return (
    <div className="w-[19.25rem] h-[16.125rem]">
      <img
        className=""
        src="/Header/profile-picture.png"
        alt="profile-picture"
      />
      <div className="relative">
        <div className="absolute inset-x-0 bottom-0 h-1/2 bg-red-500 z-10"></div>
        <div className="h-24 bg-blue-500">Parent</div>
      </div>

      <div>picture</div>
      <div>name</div>
      <div>specialization</div>
      <div>work place</div>
    </div>
  );
}
