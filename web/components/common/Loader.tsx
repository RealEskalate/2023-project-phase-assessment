import Image from "next/image";

export default function PageLoader() {
  return (
    <div className="w-full h-full my-auto flex items-center justify-center">
      <div className="flex justify-center items-center h-[400px]">
        <div className="animate-spin rounded-full border-t-4 border-blue-500 border-opacity-75 h-12 w-12"></div>
      </div>
    </div>
  );
}
