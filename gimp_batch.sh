#!/bin/bash
{
    cat <<EOF
(define (convert-xcf-to-png filename outfile)
    (let* (
            (image (car (gimp-file-load RUN-NONINTERACTIVE filename filename )))
            (drawable (car (gimp-image-merge-visible-layers image CLIP-TO-IMAGE)))
            )
        (file-png-save-defaults RUN-NONINTERACTIVE image drawable outfile outfile );.9 0 0 0 " " 0 1 0 1)
        (gimp-image-delete image) ; ... or the memory will explode
    )
)

(gimp-message-set-handler 1) ; Messages to standard output
EOF

    for i in Images/*.xcf; do
        echo "(gimp-message \"$i\")"
        echo "(convert-xcf-to-png \"$i\" \"Assets/Resources/sprites/$(basename $i .xcf).png\")"
    done

    echo "(gimp-quit 0)"

} | gimp -i -b -
