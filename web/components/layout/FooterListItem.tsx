import Image from "next/image";
import React from "react";

interface Props {
    content: string
}

const FooterListItem: React.FC<Props> = ({content}) => {
  return (
    <div className="flex space-x-2 font-extralight">
      <Image src={"./layout/rightArrow.svg"} alt={""} width={10} height={10} />
      <p>{content}</p>
    </div>
  );
};

export default FooterListItem;
