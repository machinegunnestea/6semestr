const Tag = ({ title, href }) => {
  return (
    <div>
      <a href={href} target="_blank">{title} </a>
    </div>
  );
};

export default Tag;
