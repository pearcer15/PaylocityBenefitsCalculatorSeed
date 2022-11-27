import AddDependentModal from './Modals/AddDependentModal';

const Dependent = (props) => {
    const firstName = props.firstName || '';
    const lastName = props.lastName || '';
    return (
        <tr>
            <th scope="row">{props.id}</th>
            <td>{lastName}</td>
            <td>{firstName}</td>
            <td>{props.dateOfBirth}</td>
            <td>{props.relationship}</td>
            <td>
                <a href="#" data-bs-toggle="modal" data-bs-target={`#${props.editModalId}`}>Edit</a>  <a href="#">Delete</a>
                <AddDependentModal
                    edit={true}
                    id={props.id}
                    firstName={props.firstName}
                    lastName={props.lastName}
                    dateOfBirth={props.dateOfBirth}
                    relationship={props.relationship}
                />
            </td>
        </tr>
    );
};

export default Dependent;