import Modal from 'react-modal';

function DeleteModal (props) {
    function onModalClose(event) {
        props.onCloseModal(event);
    }

    return (
        <div>
        <Modal
            isOpen={props.IsModalOpen}
            ariaHideApp={false}
        >

        <h1 className="modal-title fs-5" id="delete-modal-label">Delete</h1>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={onModalClose}></button>
                    <div className="modal-body">
                        Are you sure you want to delete {props.data.firstName} {props.data.lastName}?
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={onModalClose}>Cancel</button>
                        <button type="button" className="btn btn-primary">Delete</button>
                    </div>
            </Modal>
        </div>
    );
};

export default DeleteModal;